using System.Collections.Generic;
using System.Linq;

namespace ServiceCollectionScanner.Models
{
    public class Requirement
    {
        public List<string> directory_locations { get; set; } = new List<string>();

        public bool isLocationSpecified() => directory_locations.Any();
    }
}
