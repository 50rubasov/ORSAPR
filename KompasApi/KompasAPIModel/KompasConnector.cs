using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Kompas6API5;
using Kompas6Constants3D;

namespace KompasAPIModel
{
    /// <summary>
    /// Класс обеспечивающий запуск программы KOMPAS-3D.
    /// </summary>
    public class KompasConnector
    {
        /// <summary>
        /// Объект компаса
        /// </summary>
        public KompasObject KompasObj { get; set; }

        /// <summary>
        /// Объект трехмерного документа
        /// </summary>
        public ksDocument3D KsDocumentObj { get; set; }

        /// <summary>
        /// Метод, открывающий программу KOMPAS-3D.
        /// </summary>
        public void OpenKompas3D()
        {
            if (KompasObj == null)
            {
                var type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                KompasObj = (KompasObject)Activator.CreateInstance(type);
            }
            if (KompasObj != null)
            {
                try
                {
                    KompasObj.Visible = true;
                    KompasObj.ActivateControllerAPI();
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
        }


        /// <summary>
        /// Метод создания документа.
        /// </summary>
        public void CreateDocument()
        {
            try
            {
                if(KompasObj != null)
                {
                    if (KsDocumentObj == null)
                    {
                        KsDocumentObj = (ksDocument3D) KompasObj.Document3D();
                        KsDocumentObj.Create(false, false);
                        KsDocumentObj = (ksDocument3D)KompasObj.ActiveDocument3D();
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                throw new NullReferenceException(@"Сначала откройте KOMPAS 3D");
            }
        }

 


        /// <summary>
        /// Метод закрытия программы KOMPAS-3D.
        /// </summary>
        public void CloseKompas3D()
        {

            
            try
            {
                if (KsDocumentObj != null)
                {
                    KsDocumentObj.close();
                    KsDocumentObj = null;

                }
                KompasObj.Quit();
                KompasObj = null;
            }
            catch
            {
                throw new NullReferenceException();

            }
      
        }
    }
}
