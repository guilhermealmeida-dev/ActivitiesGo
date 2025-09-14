using System;
using System.Net;

namespace ActivitiesGo.Shared.Exceptions;

public class InactiveAccount : AppException
{
    public InactiveAccount() : base("Esta conta foi desativada e não pode ser utilizada.", HttpStatusCode.Forbidden)
    {
    }
}
