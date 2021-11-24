using System;

namespace WSPro.Backend.Utils.Exceptions
{
    public class NotExistException : Exception
    {
        public NotExistException(object id) : base(_generateMessage(id))
        {
        }

        private static string _generateMessage(object id)
        {
            return $"Object with id:({id}) don't exist!";
        }
    }
}