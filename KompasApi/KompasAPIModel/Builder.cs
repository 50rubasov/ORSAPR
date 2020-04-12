using Kompas6API5;
using Kompas6Constants3D;
using Kompas6Constants;
namespace KompasAPIModel
{
    public class Builder
    {

        /// <summary>
        /// Указатель на интерфейс.Компонент сборки
        /// </summary>
        private ksPart _ksPart;

        /// <summary>
        /// Параметры сабвуфера
        /// </summary>
        private BodyParams bodyparams = new BodyParams();

        /// <summary>
        /// Присвоение параметров сабвуфера.
        /// </summary>
        /// <param name="Setting">Параметры сабвуфера</param>
        public void ProgramKompasClassParamMethod(BodyParams Setting)
        {
            bodyparams = Setting;
        }


        /// <summary>
        /// Получаем интерфейс компонента.
        /// </summary>
        private void GetTheComponentInterfaceMethod(ksDocument3D KsDocument3D)
        {
            const int pTop_Part = -1;
            _ksPart = (ksPart)KsDocument3D.GetPart(pTop_Part);
        }
        /// <summary>
        /// Создание эскиза прямоугольника
        /// </summary>
        /// <param name="KompasObj">Объект компаса</param>
        /// <returns>Объект треугольника</returns>
        private object CreateRectangle(KompasObject KompasObj)
        {
            RectangleParam rectangleParam;
            rectangleParam = KompasObj.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            rectangleParam.height = bodyparams.Lenght;
            rectangleParam.width = bodyparams.Width;
            rectangleParam.style = 1;

            return rectangleParam;
        }

        /// <summary>
        /// Создание эскиза
        /// ksEntityDraw интерфейс элемента модели
        /// </summary>
        /// <param name="part">компонент сборки</param>
        /// <param name="axis">Ось</param>
        private void CreatSketchMethod(ksPart part,
            ksEntity ksEntityDraw, KompasObject KompasObj, ksEntity ksEntityPlane, bool OffsetPlane, bool rectangle, int TypeOfCircle)
        {
          
            //Эскиз трехмерной операции
            ksSketchDefinition _ksSketchDefinition;
            ksDocument2D _ksDocument2D;
            // GetDefinition Получение указателя интерфейса парам. объекта
            _ksSketchDefinition = (ksSketchDefinition)ksEntityDraw.
                GetDefinition();

            if (OffsetPlane == false)
            {
                // Возращение на интерфейс объекта  ( плоскость ХОУ)
                ksEntityPlane = (ksEntity)part.GetDefaultEntity
                    ((short)Obj3dType.o3d_planeXOY);
            }
            //установка плоскости, в которой расположен эскиз
            _ksSketchDefinition.SetPlane(ksEntityPlane);
            ksEntityDraw.Create();

            //Запуск режима редактирования

            _ksDocument2D = (ksDocument2D)_ksSketchDefinition.BeginEdit();

            if (rectangle == true)
            {
                _ksDocument2D.ksRectangle(CreateRectangle(KompasObj), 0);
            }
                
            else
            {
                //TypeOfCircle 1 - Саб, 2 - порт, 0 - не круг)
                if (TypeOfCircle == 1)
                {
                    if (bodyparams.NumberOfHoles == 1)
                    {
                        _ksDocument2D.ksCircle(-(bodyparams.Height / 2), -(bodyparams.Lenght/2), bodyparams.SubDiameter / 2, 1);
                    }
                    else
                    {
                        _ksDocument2D.ksCircle(-(bodyparams.Height / 2), -(bodyparams.Lenght / 4), bodyparams.SubDiameter / 2, 1);
                        _ksDocument2D.ksCircle(-(bodyparams.Height / 2), -(3* bodyparams.Lenght / 4), bodyparams.SubDiameter / 2, 1);
                    }
                }
                else if (TypeOfCircle == 2)
                {
                    _ksDocument2D.ksCircle(bodyparams.Width/2, -(bodyparams.Height / 2), bodyparams.PortDiameter/2, 1);
                }
            }
            // Интерфейс параметров для закрытия режима
            // редактирования эскиза
            _ksSketchDefinition.EndEdit();
        }

        /// <summary>
        /// Элемент выдавливания основной части короба
        /// </summary>
        /// <param name="ksEntityDraw">эскиз</param>
        /// <param name="ksEntityExtrusion">выдавливание</param>
        private void ExstrusionMethod(ksEntity ksEntityDraw,
            ksEntity ksEntityExtrusion)
        {
            ksBaseExtrusionDefinition ksBaseExtrusionDefinition =
                (ksBaseExtrusionDefinition)ksEntityExtrusion.
                GetDefinition();
            if (ksBaseExtrusionDefinition != null)
            {
                ksBaseExtrusionDefinition.directionType = (short)Direction_Type.dtNormal;
                ksBaseExtrusionDefinition.SetSideParam(true,
                    (short)End_Type.etBlind,
                    bodyparams.Height, 0, false
                    );
                ksBaseExtrusionDefinition.SetThinParam(true, (short)Direction_Type.dtReverse, 0, bodyparams.Thickness);// тонкая стенка в два направления
                ksBaseExtrusionDefinition.SetSketch(ksEntityDraw);
                ksEntityExtrusion.Create();
            }
        }

        /// <summary>
        /// Элемент выдавливания крышек короба
        /// </summary>
        /// <param name="ksEntityDraw">эскиз</param>
        /// <param name="ksEntityExtrusion">выдавливание</param>
        private void CapExstrusionMethod(ksEntity ksEntityDrawTwo,
            ksEntity ksCapEntityExtrusion)
        {
            ksBaseExtrusionDefinition ksBaseExtrusionDefinition =
                (ksBaseExtrusionDefinition)ksCapEntityExtrusion.
                GetDefinition();
            if (ksBaseExtrusionDefinition != null)
            {
                ksBaseExtrusionDefinition.directionType = (short)Direction_Type.dtNormal;
                ksBaseExtrusionDefinition.SetSideParam(true,
                    (short)End_Type.etBlind,
                    bodyparams.Thickness, 0, false
                    ) ;
                ksBaseExtrusionDefinition.SetSketch(ksEntityDrawTwo);
                ksCapEntityExtrusion.Create();
            }
        }

        /// <summary>
        /// Элемент выдавливания вырезанием
        /// </summary>
        /// <param name="ksEntityDraw">эскиз</param>
        /// <param name="ksEntityExtrusion">выдавливание</param>
        private void CutExstrusionMethod(ksEntity ksEntityDrawThree,
            ksEntity ksCutEntityExtrusion, int TypeOfCircle)
        {
            ksCutExtrusionDefinition ksCutExtrusionDefinition =
                (ksCutExtrusionDefinition)ksCutEntityExtrusion.
                GetDefinition();
            
            if (ksCutExtrusionDefinition != null)
            {
                ksCutExtrusionDefinition.cut = true;

                if (TypeOfCircle == 1)
                {
                    ksCutExtrusionDefinition.directionType = (short)Direction_Type.dtNormal;
                }
                else
                {
                    ksCutExtrusionDefinition.directionType = (short)Direction_Type.dtReverse;
                }
                ksCutExtrusionDefinition.SetSideParam(true,
                    (short)End_Type.etBlind,
                    bodyparams.Thickness, 0 ,false
                    );
                ksCutExtrusionDefinition.SetSketch(ksEntityDrawThree);
                ksCutEntityExtrusion.Create();
            }
        }

        /// <summary>
        /// Сдвиг плоскости вверх
        /// </summary>
        /// <param name="ksEntityPlaneOffset">сдиг плоскости</param>
        /// <param name="plane">плоскость</param>
        /// <param name="size">размер</param>
        private void CreatPlaneOffsetMethod(ksEntity ksEntityPlaneOffset,
            short plane, double size)
        {
            ksEntity ksEntityPlaneXOY = (ksEntity)_ksPart.
                GetDefaultEntity(plane);
            ksPlaneOffsetDefinition ksPlaneOffsetDefinition =
                (ksPlaneOffsetDefinition)ksEntityPlaneOffset.
                GetDefinition();
            ksPlaneOffsetDefinition.SetPlane(ksEntityPlaneXOY);
            ksPlaneOffsetDefinition.direction = true;
            ksPlaneOffsetDefinition.offset = size;
            ksEntityPlaneOffset.Create();
        }
        /// <summary>
        /// Формирование модели сабвуфера
        /// </summary>
        public void Build(KompasConnector KompasConnector)
        {

            KompasConnector.CreateDocument();
            ksEntity ksEntityPlane = null;
            GetTheComponentInterfaceMethod(KompasConnector.KsDocumentObj);
            ksEntity ksEntityDrawOne = (ksEntity)_ksPart.NewEntity(5);
            ksEntity ksEntityDrawTwo = (ksEntity)_ksPart.NewEntity(5);
            ksEntity ksEntityDrawThree = (ksEntity)_ksPart.NewEntity(5);
            ksEntity ksEntityDrawFour = (ksEntity)_ksPart.NewEntity(5);
            ksEntity ksEntityPlaneOffset = (ksEntity)_ksPart.NewEntity
                ((short)Obj3dType.o3d_planeOffset);
            ksEntity ksEntityExtrusion = (ksEntity)_ksPart.NewEntity
                ((int)Obj3dType.o3d_baseExtrusion);
            CreatSketchMethod(_ksPart, ksEntityDrawOne, KompasConnector.KompasObj, ksEntityPlane, false, true, 0);
            ExstrusionMethod(ksEntityDrawOne, ksEntityExtrusion);
            
            //Нижняя крышка
            ksEntity ksDownCapEntityExtrusion = (ksEntity)_ksPart.NewEntity
                ((int)Obj3dType.o3d_baseExtrusion);
            CapExstrusionMethod(ksEntityDrawOne, ksDownCapEntityExtrusion);


            //крышка сверху
            CreatPlaneOffsetMethod(ksEntityPlaneOffset,
                (short)Obj3dType.o3d_planeXOY,
                bodyparams.Height-bodyparams.Thickness);
            CreatSketchMethod(_ksPart, ksEntityDrawTwo, KompasConnector.KompasObj, ksEntityPlaneOffset, true, true, 0);
            ksEntity ksUpCapEntityExtrusion = (ksEntity)_ksPart.NewEntity
                ((int)Obj3dType.o3d_baseExtrusion);
            CapExstrusionMethod(ksEntityDrawTwo, ksUpCapEntityExtrusion);


            // построение отверстий сабвуфера 
            ksEntity ksEntityPlaneSub = (ksEntity)_ksPart.NewEntity
                ((short)Obj3dType.o3d_planeYOZ);
            CreatSketchMethod(_ksPart, ksEntityDrawThree, KompasConnector.KompasObj, ksEntityPlaneSub, true, false, 1);
            ksEntity ksSubCutEntityExtrusion = (ksEntity)_ksPart.NewEntity
                ((int)Obj3dType.o3d_cutExtrusion);
            CutExstrusionMethod(ksEntityDrawThree, ksSubCutEntityExtrusion, 1);

            // построение отверстий порта

            ksEntity ksEntityPlanePort = (ksEntity)_ksPart.NewEntity
               ((short)Obj3dType.o3d_planeXOZ);
            CreatSketchMethod(_ksPart, ksEntityDrawFour, KompasConnector.KompasObj, ksEntityPlanePort, true, false, 2);
            ksEntity ksPortCutEntityExtrusion = (ksEntity)_ksPart.NewEntity
                ((int)Obj3dType.o3d_cutExtrusion);
            CutExstrusionMethod(ksEntityDrawFour, ksPortCutEntityExtrusion, 2);
        }
    }

    
}
