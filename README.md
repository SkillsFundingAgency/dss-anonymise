# dss-anonymise
#Tool to copy and anonymise dss data from one end point to another.
Runs locally as an azure function / Rest API.
Drive via postman etc.

**Required Headers:**

- SourceEndPoint: ... End Point for existing resource
- TargetEndPoint: ... End point for target resource
- TargetKey: ...    Key for existing resource
- SourceKey: ...    Key for target resource

**Optional Header:**

- TargetPostFix: ...	If not included a default value is assigned. This should be passed with no value to keep original collection names
                   
		Request Json:
		{
			"CopyCustomer" 			 : "true",
			"CopyAddress" 			 : "true",
			"CopyContacts" 		     : "true",
			"CopyActionPlans" 	     : "true",
			"CopyActions" 		     : "true",
			"CopyAddresses" 	     : "true",
			"CopyAdviserDetails"	 : "true",
			"CopyContactDetails"	 : "true",
			"CopyCustomers" 	     : "true",
			"CopyGoals" 			 : "true",
			"CopyInteractions" 		 : "true",
			"CopyOutcomes" 			 : "true",
			"CopySessions" 			 : "true",
			"CopyWebChats"           : "true",
			"CopyDiversityDetails"	 : "true"
		}  

