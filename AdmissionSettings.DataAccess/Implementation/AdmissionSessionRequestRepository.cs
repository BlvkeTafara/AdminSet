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


namespace AdmissionSettings.DataAccess.Implementation
{
    public class AdmissionSessionRequestRepository :  IAdmissionSessionRequestRepository 
    {
        private readonly AdmissionSettingsDbContext _context;

        public AdmissionSessionRequestRepository(AdmissionSettingsDbContext context)
        {
            _context = context;
        }

        public void Add(AdmissionSessionRequest entity)
        {
            _context.AdmissionSessionRequestz.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<AdmissionSessionRequest> entities)
        {
            _context.AddRange(entities);
        }

        public IEnumerable<AdmissionSessionRequest> Find(Expression<Func<AdmissionSessionRequest, bool>> predicate)
        {
            return _context.AdmissionSessionRequestz.Where(predicate);
        }

        public IEnumerable<AdmissionSessionRequest> GetAll()
        {
            return _context.AdmissionSessionRequestz.ToList(); 
        }

        public AdmissionSessionRequest GetById(int id)
        {
            return _context.AdmissionSessionRequestz.Find(id);
        }

        public void Remove(int id)
        {
            var admissionSessionRequestdel = _context.AdmissionSessionRequestz.Where(admissionSessionRequest => admissionSessionRequest.Id == id).FirstOrDefault();

            _context.AdmissionSessionRequestz.Remove(admissionSessionRequestdel);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<AdmissionSessionRequest> entities)
        {
            _context.AdmissionSessionRequestz.RemoveRange(entities);
        }

        public void Update(AdmissionSessionRequest entity)
        {
            var admissionSessionRequestupt = _context.AdmissionSessionRequestz.Where(admissionSessionRequest => admissionSessionRequest.Id == entity.Id).FirstOrDefault();

            if (admissionSessionRequestupt != null)
            {
                admissionSessionRequestupt.Year = entity.Year;
                admissionSessionRequestupt.IsPublished = entity.IsPublished;
                admissionSessionRequestupt.EndDate = entity.EndDate;
                admissionSessionRequestupt.StartDate = entity.StartDate;
                admissionSessionRequestupt.Name = entity.Name;
            }


            _context.SaveChanges();
        }
    }
}
