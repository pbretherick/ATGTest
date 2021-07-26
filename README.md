# ATGTest
ATG Code Test

Solution:

Moved the logic to a GetLot method in a repository manager class, and the 3 repositories are now passed in as interfaces. All 3 repositories now inherit from the same abstract class.

isFailoverModeEnabled and maxFailedRequests are passed in to the repository manager constructor, to allow them to be set in the service env variables.

Its not clear how the failover repository works, or what lots are stored here.

Are only the failed to save lots stored here, in which case what is the point of the 10 minute check as the one lot we are looking for maybe the only one that failed in the last 10 mins or the only one that successfully saved.

If all the lots stored here how is the failover datetime set?

I think the likely functionality is all the lots are stored here, and any that fail have the datetime set.

Changed FailoverLots tp FailoverLot, and to inherit from Lot, to fit in with the above so any that work are saved as a Lot and any that fail are a FailoverLot. Also made DateTime nullable and added null check to the 10 minute count.

Added functionality to failbackRepository to allow it to cache result from GetFailOverLotEntries for the call to GetLot.

Rename LoadCustomer to GetLot, fixed the 10 min check to add -10 minutes

In a few of the files i fixed spacing and removed unnecessary using statements

Added unit tests for the service and manager, but not repositories as there is no db context to mock.


