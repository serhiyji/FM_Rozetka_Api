﻿using FM_Rozetka_Api.Core.DTOs.PhoneConfirmation;
using FM_Rozetka_Api.Core.Responses;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface IPhoneConfirmationService
    {
        Task<ServiceResponse> CreateConfirmPhone(CreateConfirmPhoneDto model);
        Task<ServiceResponse> ConfirmPhone(ConfirmPhoneDto model);
    }
}
