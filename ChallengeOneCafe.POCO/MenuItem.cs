using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneCafe.POCO
{
    public class MenuItem
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string MainIngredient { get; set; }
        public List<string> SideIngredients { get; set; }
        public decimal MealPrice { get; set; }
    }
}
