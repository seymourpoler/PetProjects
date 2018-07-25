using System;

namespace WiMi.Domain
{
    public class Error
    {
        public const string GeneralFieldIdError = "General";

        public string FieldId { get; }
        public string ErrorCode { get; }

        public Error(string fieldId, string errorCode)
        {
            FieldId = fieldId;
            ErrorCode = errorCode;
        }

        public Error(string errorCode)
        {
            FieldId = GeneralFieldIdError;
            ErrorCode = errorCode;
        }

        public Error(ErrorCodes errorCode)
        {
            FieldId = GeneralFieldIdError;
            ErrorCode = Convert.ToString(errorCode);
        }

        public enum ErrorCodes
        {
            Required,
            InvalidLength,
            NotFound,
            RequestCanNotBeNull
        }
    }
}
