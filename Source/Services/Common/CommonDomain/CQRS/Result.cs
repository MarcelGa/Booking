using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CommonDomain.CQRS
{
    public sealed class Result<T> : Result
    {
        private Result(Exception exception, T defaultData):base(exception)
        {
            Data = defaultData;
        }

        private Result(T data)
        {
            Data = data;
        }

        public T Data { get; }

        public static Result<T> Fail(Exception exception, T defaultData)
        {
            return new Result<T>(exception, defaultData);
        }

        public static Result<T> Ok(T data)
        {
            return new Result<T>(data);
        }
    }

    public class Result
    {
        protected Result(Exception exception)
        {
            IsSuccessful = false;
            Exception = exception;
        }
        protected Result()
        {
            IsSuccessful = true;
        }

        public bool IsSuccessful { get; }
        public Exception Exception { get; }

        public static Result Fail(Exception exception)
        {
            return new Result(exception);
        }
        public static Result Ok()
        {
            return new Result();
        }
    }
}
