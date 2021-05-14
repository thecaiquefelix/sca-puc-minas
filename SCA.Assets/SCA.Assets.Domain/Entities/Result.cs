namespace SCA.Assets.Domain.Entities
{
    public class Result
    {
        public bool Success => string.IsNullOrEmpty(Error);
        public string Error { get; set; }

        public Result()
        {
            Error = null;
        }

        public Result(string error)
        {
            Error = error;
        }
    }

    public class Result<T> : Result
    {
        public T Value { get; set; }

        public Result(T value)
        {
            Value = value;
        }

        public Result(T value, string error)
        {
            Value = value;
            Error = error;
        }
    }
}
