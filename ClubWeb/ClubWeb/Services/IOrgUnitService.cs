using Classes;

namespace ClubWeb.Services
{
    /// <summary>
    /// Service interface for retrieving organizational unit data.
    /// </summary>
    public interface IOrgUnitService
    {
        /// <summary>
        /// Gets the root organizational unit (typically IJF/Global level).
        /// </summary>
        OrgUnit GetRoot();
    }
}

