﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saman.Test.Backend.Domain.Common
{
    public enum ErrorCode : short
    {
        Successful = 2001,

        //NotFound = 4041,

        //UndefinedService = 4042,

        //ThirdPartyServiceNotFound = 4043,

        BadRequest = 400,

        //InvalidMsisdn = 4001,

        //InvalidOtpTime = 4002,

        //InCompleteRegistrations = 4004,

        //InvalidTraceCode = 4005,

        //Unauthorized = 4010,

        //LockedUser = 4011,

        Forbidden = 403,

        //InvalidOtp = 4031,

        //Conflicts = 4090,

        JwtKeyNotFound = 4011,

        InvalidJwtSignature = 4012,

        UnknownServerError = 500,

        //FailedSendSms = 600,

        //FailedPayment = 601,

        //SuspiciousPayment = 602,

        TooManyRequest = 429,

        //UnsupportedMediaType = 4150,

        //ImageTooLarge = 4008,

        //ImageTooSmall = 4009,
    }
}
