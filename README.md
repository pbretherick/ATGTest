# ATGTest
ATG Code Test

Solution:

Considered a Factory class, but as the archive repository could be used after the other 2 it doesnt really fit
Considered a Chain-of-responsibility class, but as the 3 repositories are fixed in number and the order they are queried, it also doesn't fit
Best solution seemed to be to move the logic to a GetLot method in a repository manager class.
The 3 repositories are passed in as interfaces to allow for mocked unit tests.



Check for lot.IsArchived - lot maybe null, and maybe returned from the main repository.
Rename LoadCustomer to GetLot

Lot.cs
fixed spacing
removed unnecessary using

LotRepository.cs
removed unnecessary using

FailoverLots.cs
removed unnecessary using


