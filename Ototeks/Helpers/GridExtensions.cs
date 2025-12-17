using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Ototeks.UI.Helpers // Namespace'i kendine göre ayarla
{
    public static class GridExtensions
    {
        public static void ActivateMasterDetail<T>(this GridView view, string relationName, Func<T, IEnumerable> getListFunc) where T : class
        {
            //Olayları (Events) Dinamik Olarak Bağla

            // Soru 1: Kaç detay var? -> 1 tane.
            view.MasterRowGetRelationCount += (s, e) => e.RelationCount = 1;

            // Soru 2: Adı ne? -> relationName parametresi.
            view.MasterRowGetRelationName += (s, e) => e.RelationName = relationName;

            // Soru 3: Liste nerede? -> getListFunc kuralını çalıştır.
            view.MasterRowGetChildList += (s, e) =>
            {
                var gridView = s as GridView;
                var rowObj = gridView.GetRow(e.RowHandle) as T;

                if (rowObj != null)
                {
                    // Listeyi al ve Grid'e ver
                    var list = getListFunc(rowObj);
                    if (list != null)
                    {
                        e.ChildList = list as IList;
                    }
                }
            };
        }
    }
}