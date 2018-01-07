using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebGrid.Models
{
    public class Menu
    {
        public int menuId { get; set; }
        public string menuName { get; set; }
        public string menuURL { get; set; }
        public int parentId { get; set; }
       
    }

    public static class MenuRepo
    {
        public static IEnumerable<Menu> GetMenus()
        {
            var menu = new List<Menu>();

            menu.Add(new Menu { menuId = 1, menuName = "test1", menuURL = "#", parentId = 0 });
            menu.Add(new Menu { menuId = 2, menuName = "test2", menuURL = "#", parentId = 0 });
            menu.Add(new Menu { menuId = 3, menuName = "test3", menuURL = "#", parentId = 0 });
            menu.Add(new Menu { menuId = 4, menuName = "test4", menuURL = "#", parentId = 0 });
            menu.Add(new Menu { menuId = 5, menuName = "child_test1", menuURL = "c1", parentId = 1 });
            menu.Add(new Menu { menuId = 6, menuName = "child_test2", menuURL = "c2", parentId = 2 });

            menu.Add(new Menu { menuId = 7, menuName = "subchild1", menuURL = "subchild1", parentId = 5 });

            //menu.Add(new Menu { menuId = 8, menuName = "child_test3", menuURL = "child_test3", parentId = 3 });
            //menu.Add(new Menu { menuId = 9, menuName = "child_test4", menuURL = "child_test4", parentId = 4 });
            //menu.Add(new Menu { menuId = 10, menuName = "subchild2", menuURL = "subchild2", parentId = 5 });


            //menu.Add(new Menu { menuId = 11, menuName = "test11", menuURL = "#", parentId = 0 });
            //menu.Add(new Menu { menuId = 12, menuName = "test12", menuURL = "#", parentId = 0 });

            return menu;
        }
    }
}