﻿using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace ofplug.Logic.Abstract
{
	public abstract class AbstractCodeActivity : CodeActivity
	{
		public bool IsTest = false;

		protected ITracingService _tracingService;
		protected IOrganizationService _service;
		protected crm.Config _config;
		protected of.Connection _of_connection;

		private of.ISender _sender_test;

		protected void Initialize(CodeActivityContext codeActivityContext)
		{
			if (IsTest == false)
			{
				_tracingService = codeActivityContext.GetExtension<ITracingService>();

				IWorkflowContext workflowContext = codeActivityContext.GetExtension<IWorkflowContext>();
				IOrganizationServiceFactory serviceFactory = codeActivityContext.GetExtension<IOrganizationServiceFactory>();
				_service = serviceFactory.CreateOrganizationService(workflowContext.UserId);
			}

			_config = new crm.Config(_service, _tracingService);
			_of_connection = new of.Connection(_config.Nrq_of_url, _config.Nrq_of_token);

			if (IsTest)
			{
				_of_connection.Replace_sender(_sender_test);
			}
		}

		public void Set_test(ITracingService tracingService, IOrganizationService service, of.ISender sender)
		{
			_tracingService = tracingService;
			_service = service;
			_sender_test = sender;
		}

		protected void Write_exception(Exception exception)
		{
			if (_tracingService != null)
			{
				_tracingService.Trace(_get_exception_string(exception));
			}
			throw exception;
		}

		private string _get_exception_string(Exception exception)
		{
			if (exception == null)
			{
				return string.Empty;
			}

			return
				exception.Message + Environment.NewLine +
				exception.StackTrace + Environment.NewLine +
				_get_exception_string(exception.InnerException);
		}
	}
}
