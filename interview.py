#!/usr/bin/python
#interview question
source = { 
	"name" : "Hipster Bistro", 
	"location" : { 
		"address1" : "123 Somewhere St.", 
		"address2" : "Ste 300", 
		"city" : "Sandyvale", 
		"zip" : 94117 
	}, 
	"alternate_names" : ["The Histro", "Thick Beard Cafe"] 
} 

destination = {} 

#create closure
def makeCopier(source, destination):
	def copy(name, destName=None):
		paths = name.split('.')
		if len(paths)>1 and paths[0] in source.keys():
			 	if type(source[paths[0]]) == list:
			 		destination[destName] = source[paths[0]][int(paths[1])]
			 	elif paths[1] in source[paths[0]].keys():
					if not destName:
						destName=paths[-1]
					destination[destName] = source[paths[0]][paths[1]]
		
		if  name in source.keys():
			if destName == None:
				destName=name
			destination[destName] = source[name]
	return copy

copy = makeCopier(source, destination) 

 # Copy with no second argument takes the last path component. 
copy('name') 
copy('location.city') 

 # Copy with a second argument uses that for the destination field name. 
copy('location.address1', 'streetAddress') 

 # Arrays can be accessed by integer ".0" accesses the first element. 
copy('alternate_names.0', 'alternateName') 

 # Missing fields should not result in anything getting added. 
copy('contact.phone', 'phoneNumber') 
copy('contact.emails.0', 'primaryEmail') 
copy('contact.emails.1', 'secondaryEmail') 

print(destination) 

# Expected output 
# 
# % node nested.js 
# { 
# "name": "Hipster Bistro", 
# "city": "Sandyvale", 
# "streetAddress": "123 Somewhere St.", 
# "alternateName": "The Histro" 
# } 
