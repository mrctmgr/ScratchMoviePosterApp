using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace denemIMDB
{
    public class Registration
    {
        public string Id { get; set; }
        public int No { get; set; }
        public string Name { get; set; } = "Empty";
        public List<string> Movies = new List<string>()
        {
            "", "City Of God", "Good Fellas", "Leon", "Inglodious Basterds", "Spirited Away", "The Departed", "3096 Days", "Airplane", "Before Sunrise",
            "Before Midnight", "Andhadhun", "A Men Called Otto", "I'm Thinking Of Ending Things", "Children Of Men", "Blindness", "Before Sunset",
            "Midsommar","Manifest", "Issiz Adam", "In The Tall Grass", "Sick", "Old", "No Escape", "My Sister's Keeper", "The Visit", 
            "The Invasion", "The Guilty", "The Darkes Mind", "The Timer", "Tomorrowland"
        };

        
        
    }
}
