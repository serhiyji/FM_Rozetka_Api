using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities;

namespace FM_Rozetka_Api.Core.Specifications
{
    public static class RefreshTokenSpecification
    {
        public class GetRefreshToken : Specification<RefreshToken>
        {
            public GetRefreshToken(string refreshToken)
            {
                Query.Where(t => t.Token == refreshToken);
            }
        }
        public class GetAllTokensByUserId : Specification<RefreshToken>
        {
            public GetAllTokensByUserId(string userId)
            {
                Query.Where(t => t.UserId == userId);
            }
        }
    }
}
