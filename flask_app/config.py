browser = ["Chrome"]
# Enter your Linkedin password and username below. Do not commit this file after entering these credentials.
# Linkedin credentials
email = "email"
password = "password"


headless = False
# # get Firefox profile path by typing following url: about:profiles
# firefoxProfileRootDir = r"/home/ongun/snap/firefox/common/.mozilla/firefox/pz0eh58h.Linkedin_bot"
# # get Chrome profile path by typing following url: chrome://version/
chromeProfilePath = r""


# These settings are for running Linkedin job apply bot
# location you want to search the jobs - ex : ["Poland", "Singapore", "New York City Metropolitan Area", "Monroe County"]
# continent locations:["Europe", "Asia", "Australia", "NorthAmerica", "SouthAmerica", "Africa", "Australia"]
location = ["Miami"]
# keywords related with your job search
keywords = ["software developer", "frontend developer", "react", "javascript", "python", "mysql", "software engineer"]
#job experience Level - ex:  ["Internship", "Entry level" , "Associate" , "Mid-Senior level" , "Director" , "Executive"]
experienceLevels = [ "Entry level", "Associate" ]
#job posted date - ex: ["Any Time", "Past Month" , "Past Week" , "Past 24 hours"] - select only one
datePosted = ["Past Month"]
#job type - ex:  ["Full-time", "Part-time" , "Contract" , "Temporary", "Volunteer", "Intership", "Other"]
jobType = ["Full-time"]
#remote  - ex: ["On-site" , "Remote" , "Hybrid"]
remote = ["Remote" , "Hybrid"]
#salary - ex:["$40,000+", "$60,000+", "$80,000+", "$100,000+", "$120,000+", "$140,000+", "$160,000+", "$180,000+", "$200,000+" ] - select only one
salary = [ "$60,000+"]
#sort - ex:["Recent"] or ["Relevant"] - select only one
sort = ["Relevant"]
#Blacklist companies you dont want to apply - ex: ["Apple","Google"]
blacklistCompanies = []
#Blaclist keywords in title - ex:["manager", ".Net"]
blackListTitles = []
#Follow companies after sucessfull application True - yes, False - no
followCompanies = False

# Testing features
displayWarnings = False