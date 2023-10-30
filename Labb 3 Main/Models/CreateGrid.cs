using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Labb_3_Main.Models
{
    public static class CreateGrid
    {
        public static void Grid_2_By_3(Grid mainGrid)
        {
            mainGrid.Children.Clear();
            mainGrid.RowDefinitions.Clear();
            mainGrid.ColumnDefinitions.Clear();

            for (int i = 0; i < 5; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                mainGrid.ColumnDefinitions.Add(column);

                if (i == 0 || i == 4)
                {
                    column.Width = new GridLength(20);
                }
                else if(i == 1)
                {
                    column.Width = new GridLength(100, GridUnitType.Pixel);
                }
                else
                {
                    column.Width = new GridLength(620, GridUnitType.Pixel);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                RowDefinition row = new RowDefinition();
                mainGrid.RowDefinitions.Add(row);

                if (i == 0 || i == 4)
                {
                    row.Height = new GridLength(20, GridUnitType.Pixel);
                }
                else if (i == 1)
                {
                    row.Height = new GridLength(50, GridUnitType.Pixel);
                }
                else
                {
                    row.Height = new GridLength(204, GridUnitType.Pixel);
                }
            }

        }

        public static void Grid_3_By_3(Grid mainGrid)
        {
            mainGrid.Children.Clear();
            mainGrid.RowDefinitions.Clear();
            mainGrid.ColumnDefinitions.Clear();

            for (int i = 0; i < 9; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                mainGrid.ColumnDefinitions.Add(column);

                if (i == 0 || i == 8)
                {
                    column.Width = new GridLength(20);
                }
                else if (i == 1)
                {
                    column.Width = new GridLength(100);
                }
                else
                {
                    column.Width = new GridLength(200, GridUnitType.Pixel); // When set to (* / Star) they become really small for some reason
                }
            }

            for (int i = 0; i < 10; i++)
            {
                RowDefinition row = new RowDefinition();
                mainGrid.RowDefinitions.Add(row);

                if (i == 0 || i == 9) // allt plus 1
                {
                    row.Height = new GridLength(20, GridUnitType.Pixel);
                }
                else if (i == 1)
                {
                    row.Height = new GridLength (50, GridUnitType.Pixel);
                }
                else if (i == 3 || i == 7)
                {
                    row.Height = new GridLength(50, GridUnitType.Pixel);
                }
                else if (i == 8)
                {
                    row.Height = new GridLength(0, GridUnitType.Auto);
                }
                else
                {
                    row.Height = new GridLength(0, GridUnitType.Auto);
                }
            }
        }
    }
}
