using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Ototeks.UI.Helpers
{
    public static class GridExtensions
    {
        public static void ActivateMasterDetail<T>(this GridView view, string relationName, Func<T, IEnumerable> getListFunc) where T : class
        {
            // Bind events dynamically

            // Question 1: How many detail relations? -> 1.
            view.MasterRowGetRelationCount += (s, e) => e.RelationCount = 1;

            // Question 2: What is the relation name? -> the relationName parameter.
            view.MasterRowGetRelationName += (s, e) => e.RelationName = relationName;

            // Question 3: Where is the child list? -> execute the getListFunc delegate.
            view.MasterRowGetChildList += (s, e) =>
            {
                var gridView = s as GridView;
                var rowObj = gridView.GetRow(e.RowHandle) as T;

                if (rowObj != null)
                {
                    // Get the list and provide it to the Grid
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
