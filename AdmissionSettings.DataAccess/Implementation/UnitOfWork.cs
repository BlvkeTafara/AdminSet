using AdmissionSettings.DataAccess.Context;
using AdmissionSettings.Domain.Entities;
using AdmissionSettings.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionSettings.DataAccess.Implementation
{
    public class UnitOfWork : IUnitOfWorkRepository
    {
        private readonly AdmissionSettingsDbContext _context;

        public UnitOfWork(AdmissionSettingsDbContext context)
        {
            _context = context;
            AdmissionSession = new AdmissionSessionRepository (_context);
            AdmissionSessionRequest = new AdmissionSessionRequestRepository (_context);
        }
        public IAdmissionSessionRepository AdmissionSession { get; private set; }    
        public IAdmissionSessionRequestRepository AdmissionSessionRequest { get; private set; }

        public int Save()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
