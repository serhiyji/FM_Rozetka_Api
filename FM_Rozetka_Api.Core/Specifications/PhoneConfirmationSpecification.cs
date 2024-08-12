using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities;

namespace FM_Rozetka_Api.Core.Specifications
{
    public static class PhoneConfirmationSpecification
    {
        public class GetByAppUserId : Specification<PhoneConfirmation>
        {
            public GetByAppUserId(string appUserId)
            {
                Query.Where(item => item.AppUserId == appUserId);
            }
        }

        public class GetByPhoneNumber : Specification<PhoneConfirmation>
        {
            public GetByPhoneNumber(string phoneNumber)
            {
                Query.Where(item => item.Phone == phoneNumber);
            }
        }
    }
}
