using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Molder.Db
{
    public class Index
    {

        public string Name { get; set; }
        public string Type { get; set; }

        public bool? Unique { get; set; }
        public Dictionary<string, string> Columns = new Dictionary<string, string>();
        public Spatial Spatial { get; set; }

        public bool Equals(Index target)
        {
            var col1 = string.Join("__", Columns.Select(x => $"{x.Key},{x.Value}"));
            var col2 = string.Join("__", target.Columns.Select(x => $"{x.Key},{x.Value}"));
            var spacial = (Spatial ?? new Spatial()).Equals(target.Spatial ?? new Spatial());
            return Unique == target.Unique && Type == target.Type && col1 == col2 && spacial;
        }

    }

    public class Spatial
    {
        public string TessellationSchema { get; set; }
        public string Level1 { get; set; }
        public string Level2 { get; set; }
        public string Level3 { get; set; }
        public string Level4 { get; set; }
        public int? CellsPerObject { get; set; }

        public bool Equals(Spatial target)
        {
            return TessellationSchema?.ToLower() == target.TessellationSchema?.ToLower() &&
                   Level1?.ToLower() == target.Level1?.ToLower() &&
                   Level2?.ToLower() == target.Level2?.ToLower() && 
                   Level3?.ToLower() == target.Level3?.ToLower() &&
                   Level4?.ToLower() == target.Level4?.ToLower() &&
                   CellsPerObject == target.CellsPerObject;
        }
    }
}