using System;
using Classes;

namespace ClubWeb.Services
{
    /// <summary>
    /// In-memory service for organizational unit data.
    /// Later, this will be replaced with an EF Core-based implementation.
    /// </summary>
    public sealed class OrgUnitService : IOrgUnitService
    {
        private readonly OrgUnit _Root;

        public OrgUnitService()
        {
            OrgUnit ijf = new OrgUnit
            {
                Id = Guid.NewGuid(),
                Name = "IJF",
                OrgType = Enums.OrgType.Global
            };

            OrgUnit judoAustralia = new OrgUnit
            {
                Id = Guid.NewGuid(),
                Name = "Judo Australia",
                OrgType = Enums.OrgType.Country,
                ParentOrgUnitId = ijf.Id
            };

            OrgUnit judoWA = new OrgUnit
            {
                Id = Guid.NewGuid(),
                Name = "JudoWA",
                OrgType = Enums.OrgType.State,
                ParentOrgUnitId = judoAustralia.Id
            };

            OrgUnit southwestAcademy = new OrgUnit
            {
                Id = Guid.NewGuid(),
                Name = "Southwest Judo Academy",
                OrgType = Enums.OrgType.Club,
                ParentOrgUnitId = judoWA.Id
            };

            judoWA.ChildOrgUnits.Add(southwestAcademy);
            judoAustralia.ChildOrgUnits.Add(judoWA);
            ijf.ChildOrgUnits.Add(judoAustralia);

            _Root = ijf;
        }

        public OrgUnit GetRoot()
        {
            return _Root;
        }
    }
}

