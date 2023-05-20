namespace englishtotamil.Models{
			using System;
			using System.ComponentModel.DataAnnotations;
			using Microsoft.AspNetCore.Mvc;
			using System.Collections.Generic;
			using FluentValidation;
			using System.Linq;
			//This code generated from Deliveries Powered by Mahat, Source Machine : 15.206.208.9 , Build Number : Build 14092021 #2021-09-014(Updated on 29102021 12:49) on 05/19/2023 09:16:58
			public class tenantModel
			{

			 public System.Guid ?tenantid	{ get; set; }

[xssFilter]
public String businessname{ get; set; }

[xssFilter]
public String businessemail{ get; set; }

[xssFilter]
public String businessphone{ get; set; }

[xssFilter]
public String businesswebsite{ get; set; }

[xssFilter]
public String organizationlogo{ get; set; }

public int? numberofemployees{ get; set; }

[xssFilter]
public String addressline1{ get; set; }

[xssFilter]
public String addressline2{ get; set; }

[xssFilter]
public String city{ get; set; }

[xssFilter]
public String state{ get; set; }

[xssFilter]
public String zip{ get; set; }

[xssFilter]
public String country{ get; set; }
public System.Guid ?createduser	{ get; set; }
[DataType(DataType.Date)]
[ModelBinder(BinderType = typeof(DateTimeModelBinder))]
[DisplayFormat(DataFormatString="{0:dd/MM/yyyy}", ApplyFormatInEditMode=true)]
public System.DateTime ?createddate	{ get; set; }
public System.Guid ?modifieduser	{ get; set; }
[DataType(DataType.Date)]
[ModelBinder(BinderType = typeof(DateTimeModelBinder))]
[DisplayFormat(DataFormatString="{0:dd/MM/yyyy}", ApplyFormatInEditMode=true)]
public System.DateTime ?modifieddate	{ get; set; }
public bool isdeleted	{ get; set; }
[xssFilter]
                        [Required(ErrorMessage = "craftmyapp_actionmethodname is required,please pass current action name")]
                        public String craftmyapp_actionmethodname{ get; set; }



			}
			

			public class tenantModelValidator: AbstractValidator<tenantModel>
			{
					 
					public tenantModelValidator()
					{

						 When(model => model.craftmyapp_actionmethodname == "Create_tenant", () =>
                                    {
                                        {RuleFor(m => m.businessname)
.NotEmpty().WithMessage("Business  Name is required")
.MaximumLength(50).WithMessage("The allowed length of Business  Name is 50 characters or fewer")
;
RuleFor(m => m.businessemail)
.NotEmpty().WithMessage("Business  Email is required")
.MaximumLength(128).WithMessage("The allowed length of Business  Email is 128 characters or fewer")
.EmailAddress()

;
RuleFor(m => m.businessphone)
.NotEmpty().WithMessage("Business  Phone is required")
.MaximumLength(20).WithMessage("The allowed length of Business  Phone is 20 characters or fewer ")

;


RuleFor(m => m.numberofemployees)
.LessThanOrEqualTo(99999999).WithMessage("Number of  Employees should be LessThanOrEqualTo 99999999")

;






}

                                    });
When(model => model.craftmyapp_actionmethodname == "Update_tenant", () =>
                                    {
                                        {RuleFor(m => m.businessname)
.NotEmpty().WithMessage("Business  Name is required")
.MaximumLength(50).WithMessage("The allowed length of Business  Name is 50 characters or fewer")
;
RuleFor(m => m.businessemail)
.NotEmpty().WithMessage("Business  Email is required")
.MaximumLength(128).WithMessage("The allowed length of Business  Email is 128 characters or fewer")
.EmailAddress()

;
RuleFor(m => m.businessphone)
.NotEmpty().WithMessage("Business  Phone is required")
.MaximumLength(20).WithMessage("The allowed length of Business  Phone is 20 characters or fewer ")

;


RuleFor(m => m.numberofemployees)
.LessThanOrEqualTo(99999999).WithMessage("Number of  Employees should be LessThanOrEqualTo 99999999")

;






}

                                    });

						 
						
					}

			}

			

            


 


			}
