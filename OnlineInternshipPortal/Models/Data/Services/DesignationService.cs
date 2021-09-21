using OnlineInternshipPortal.Models.Data.OnlineInternshipContext;
using OnlineInternshipPortal.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal.Models.Data.Services
{
    public class DesignationService
    {
        private OnlineInternshipContext.OnlineInternshipContext _Context;
        public DesignationService(OnlineInternshipContext.OnlineInternshipContext context)
        {
            _Context= context;
        }

        //Create list of Designation
        public List<DesignationViewModel> GetDesignations()
        {
            List<Designation> designations = _Context.Designations.ToList();
            List<DesignationViewModel> model = designations.Select(x => new DesignationViewModel
            {
                DesignationId = x.DesignationId,
                DesignationName = x.DesignationName
            }).ToList();

            return model;
        }

        //Add new data into designation table
        public bool AddDesignation(DesignationViewModel model)
        {
            Designation designation = new Designation()
            {
                DesignationName = model.DesignationName
            };

            _Context.Designations.Add(designation);
            _Context.SaveChanges();

            return true;
        }

        //update data
        public bool UpdateDesignation(DesignationViewModel model)
        {
            Designation designation = _Context.Designations.Where(x => x.DesignationId == model.DesignationId).FirstOrDefault();
            designation.DesignationName = model.DesignationName;
            _Context.Designations.Update(designation);
            _Context.SaveChanges();

            return true;

        }

        //Delete data
        public bool DeleteDesignation(int id)
        {
            Designation designation = _Context.Designations.Where(x => x.DesignationId == id).FirstOrDefault();
            _Context.Designations.Remove(designation);
            _Context.SaveChanges();

            return true;
        }

        //Get details of designation table

        public DesignationViewModel GetDesignationDetails(int id) 
        {
            Designation designation = _Context.Designations.Where(x => x.DesignationId == id).FirstOrDefault();
            DesignationViewModel model = new DesignationViewModel
            {
                DesignationId = designation.DesignationId,
                DesignationName = designation.DesignationName

            };

            return model;

        }


    }
}
