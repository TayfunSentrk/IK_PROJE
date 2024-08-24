using MediatR;

namespace IKProje.Application.Features.PermissionFeatures.PermissionQueries.PermissionGetSingleForEdit
{
    public class PermissonGetSingleForEditCommand:IRequest<PermissonViewForEdit>
    {

        public string Id { get; set; }

        public bool IsTracking { get; set; } = true;
    }
}