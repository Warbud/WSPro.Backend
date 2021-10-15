using WSPro.Backend.Model.General;

namespace WSPro.Backend.Model
{
    public class DelayCause : EntityModificationDate
    {
        public DelayCause()
        {
        }

        public DelayCause(string name, DelayCause? parent = null)
        {
            Name = name;
            if (parent is null)
            {
                IsMain = true;
            }
            else
            {
                Parent = parent;
                IsMain = false;
            }
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public virtual DelayCause Parent { get; set; }
        private int? ParentId { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}