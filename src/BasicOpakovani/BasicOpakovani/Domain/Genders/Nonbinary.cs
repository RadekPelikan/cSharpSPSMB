namespace BasicOpakovani.Domain
{
    public class Nonbinary : Person
    {
        public int LimbNum;

        public Nonbinary(string name, int age, int weight, int limbNum) : base(name, age, weight)
        {
            LimbNum = limbNum;
        }

        public void CutLimb()
        {
            if (LimbNum > 0) LimbNum--;
        }
    }
}