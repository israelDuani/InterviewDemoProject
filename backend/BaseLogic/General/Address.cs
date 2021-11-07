
namespace BaseLogic.General
{
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Address))
            {
                return false;
            }
            return (this.Street == ((Address)obj).Street)
                && (this.City == ((Address)obj).City);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
