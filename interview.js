var source = { 
"name" : "Hipster Bistro", 
"location" : { 
"address1" : "123 Somewhere St.", 
"address2" : "Ste 300", 
"city" : "Sandyvale", 
"zip" : 94117 
}, 
"alternate_names" : ["The Histro", "Thick Beard Cafe"] 
}; 

var destination = {}; 

var copy = makeCopier(source, destination); 

// Copy with no second argument takes the last path component. 
copy('name'); 
copy('location.city'); 

// Copy with a second argument uses that for the destination field name. 
copy('location.address1', 'streetAddress'); 

// Arrays can be accessed by integer; ".0" accesses the first element. 
copy('alternate_names.0', 'alternateName'); 

// Missing fields should not result in anything getting added. 
copy('contact.phone', 'phoneNumber'); 
copy('contact.emails.0', 'primaryEmail'); 
copy('contact.emails.1', 'secondaryEmail'); 


function makeCopier(source, destination)
{
    
    function copyIt(sourcePath, destinationPath)
    {
        pathSplit = sourcePath.split('.');
        if ((pathSplit[0] in source) == false) {
            return;
        }
        
        if (destinationPath == null)
        {
            destination[sourcePath]= source[sourcePath];
            
            destination[pathSplit[1]]= source[pathSplit[0]][pathSplit[1]];
        }
        else
        {
           destination[destinationPath]= source[pathSplit[0]][pathSplit[1]];
        }
        
    }
    return copyIt
}

console.log(JSON.stringify(destination, undefined, 2)); 

// Expected output 
// 
// % node nested.js 
// { 
// "name": "Hipster Bistro", 
// "city": "Sandyvale", 
// "streetAddress": "123 Somewhere St.", 
// "alternateName": "The Histro" 
// } 
