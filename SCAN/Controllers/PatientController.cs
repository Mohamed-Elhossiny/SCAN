﻿using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SCAN.Enums;
using SCAN.Repositories.PatientRepository;
using SCAN.ViewModels;

namespace SCAN.Controllers
{
	public class PatientController : Controller
	{
		private readonly IPatientRepository patientRepository;
		private readonly INotyfService notifyService;

		public PatientController(IPatientRepository patientRepository, INotyfService notifyService)
		{
			this.patientRepository = patientRepository;
			this.notifyService = notifyService;
		}

		[HttpGet]
		public IActionResult CreateAppointment()
		{
			var patientVM = new PatientVM
			{
				ReferenceList = patientRepository.GetReferenceList(),
				CheckTypeList =patientRepository.GetCheckTypeList()
			};
			return View(patientVM);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateAppointment(PatientVM patientVM)
		{
			var modelVM = new PatientVM();
			if (ModelState.IsValid == true)
			{
				var isadded = patientRepository.AddPatient(patientVM);
				if(isadded == true)
				{
					notifyService.Success("The appointment has added successfully");
					modelVM = new PatientVM
					{
						ReferenceList = patientRepository.GetReferenceList(),
						CheckTypeList = patientRepository.GetCheckTypeList()
					};
					return RedirectToAction("GetAllPatients");
				}
				notifyService.Error("Error in add appointment");
			}
			patientVM.ReferenceList = patientRepository.GetReferenceList();
			patientVM.CheckTypeList = patientRepository.GetCheckTypeList();
			return View(patientVM);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllPatients()
		{
			var allPatients = await patientRepository.GetAllPatients();
			return View(allPatients);
		}
	}
}
