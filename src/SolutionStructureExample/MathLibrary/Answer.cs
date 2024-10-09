namespace App
{
    public class Answer
    {
        public Operation operation;
        public double result;

        public Answer(Operation operation, double result)
        {
            this.operation = operation;
            this.result = result;
        }

        public override string ToString()
        {
            return $"{operation} {result}";
        }
    }
}