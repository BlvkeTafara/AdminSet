using AdmissionSettings.DataAccess.Context;
using AdmissionSettings.Domain.Entities;
using AdmissionSettings.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdmissionSettings.DataAccess.Implementation
{
    public class AdmissionSessionRepository : IAdmissionSessionRepository 
    {
        private readonly AdmissionSettingsDbContext _context;
        public AdmissionSessionRepository(AdmissionSettingsDbContext context)
        {
            _context = context;
        }

        public void Add(AdmissionSession entity)
        {
            _context.AdmissionSessions.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<AdmissionSession> entities)
        {
            _context.AdmissionSessions.AddRange(entities);
        }

        public IEnumerable<AdmissionSession> Find(Expression<Func<AdmissionSession, bool>> predicate)
        {
            return _context.AdmissionSessions.Where(predicate);
        }

        public IEnumerable<AdmissionSession> GetAll()
        {
            return _context.AdmissionSessions.ToList();

        }

        public AdmissionSession GetById(int id)
        {
            return _context.AdmissionSessions.Find(id);
        }

       

        public void Remove(int id)
        {
            var admissionSessiondel = _context.AdmissionSessions.Where(admissionSession => admissionSession.Id == id).FirstOrDefault();
            
            _context.AdmissionSessions.Remove(admissionSessiondel);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<AdmissionSession> entities)
        {
            _context.AdmissionSessions.RemoveRange(entities);
        }

        public void Update(AdmissionSession entity)
        {
            var admissionSessionupt =  _context.AdmissionSessions.Where(admissionSession  => admissionSession.Id == entity.Id ).FirstOrDefault();
        
            if (admissionSessionupt != null)
            {
                admissionSessionupt.Year = entity.Year;
                admissionSessionupt.IsPublished = entity.IsPublished;
                admissionSessionupt.EndDate = entity.EndDate;
                admissionSessionupt.StartDate = entity.StartDate;
                admissionSessionupt.Name = entity.Name;
            }
     

            _context.SaveChanges();
        }
    }
}
