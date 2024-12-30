<Query Kind="Statements">
  <Connection>
    <ID>e19d4be1-b7d5-406e-bc4f-6fc6ec42f90e</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>NexaWorks</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
  <RuntimeVersion>8.0</RuntimeVersion>
</Query>

{
	//all variable
    int productId1 = 1;//products
    int productId3 = 3;
    int versionId3 = 3;//versions
    int versionId6 = 6;
    int versionId9 = 9;
	DateOnly dateStart = new DateOnly(2023,01,01);//dates
	DateOnly dateEnd = new DateOnly(2023,12,31);
	List<string> allWords = new List<string>{"utilisateur"};//list words
	
	//1
    // Requête pour les tickets non résolus
    var GetAllTicketsSolved = Tickets
        .Where(t => t.IsResolved == true)
        .ToList();
    // Affichage des résultats
    GetAllTicketsSolved.Dump();/**/
	
	//2
    // Requête pour les tickets non résolus d'un produit spécifique
    var GetAllTicketsSolvedOfThisProductID = Tickets
        .Where(t => t.IsResolved == true 
            && t.AssociatedVersionOS.VersionKey.ProductKeyId == productId1)
        .ToList();
    // Affichage des résultats
    GetAllTicketsSolvedOfThisProductID.Dump();/**/
	
	//3
    // Requête pour les tickets non résolus d'une version spécifique
    var GetAllTicketsSolvedOfThisVersionID = Tickets
        .Where(t => t.IsResolved == true 
            && t.AssociatedVersionOS.VersionKeyId == versionId3)
        .ToList();
    // Affichage des résultats
    GetAllTicketsSolvedOfThisVersionID.Dump();/**/
	
	//4
    var GetAllTicketsOfThisProductIDSolvedInThisTimeLap = Tickets
        .Where(t => t.IsResolved == true
    		&& t.AssociatedVersionOS.VersionKey.ProductKeyId == productId1
    		&& t.DateResolve >= dateStart
    		&& t.DateResolve <= dateEnd);
	GetAllTicketsOfThisProductIDSolvedInThisTimeLap.Dump();/**/
	
	//5
	var GetAllTicketsOfThisVersionIDSolvedInThisTimeLap = Tickets
		.Where(t => t.IsResolved == true
    		&& t.AssociatedVersionOS.VersionKeyId == versionId3
    		&& t.DateResolve >= dateStart
    		&& t.DateResolve <= dateEnd);
	GetAllTicketsOfThisVersionIDSolvedInThisTimeLap.Dump();/**/
	
	//6
	var GetAllTicketsSolvedWithTheseWords = Tickets
		.Where(t => t.IsResolved == true
            && t.Description != null)
    	.AsEnumerable() // Ramène les données dans la mémoire locale
    	.Where(t => allWords.All(word => t.Description.Contains(word)));
	GetAllTicketsSolvedWithTheseWords.Dump();/**/
	
	//7
	var GetAllTicketsSolvedOfThisProductIDWithTheseWords = Tickets
		.Where(t => t.IsResolved == true
    		&& t.AssociatedVersionOS.VersionKey.ProductKeyId == productId3
    		&& t.Description != null)
    	.AsEnumerable() // Ramène les données dans la mémoire locale
    	.Where(t => allWords.All(word => t.Description.Contains(word)));
	GetAllTicketsSolvedOfThisProductIDWithTheseWords.Dump();/**/
	
	//8
	var GetAllTicketsSolvedOfThisVersionIDWithTheseWords = Tickets
		.Where(t => t.IsResolved == true
    		&& t.AssociatedVersionOS.VersionKeyId == versionId6
    		&& t.Description != null)
    	.AsEnumerable() // Ramène les données dans la mémoire locale
    	.Where(t => allWords.All(word => t.Description.Contains(word)));
	GetAllTicketsSolvedOfThisVersionIDWithTheseWords.Dump();/**/
	
	//9
	var GetAllTicketsOfThisProductIDWithTheseWordsSolvedInThisTimeLap = Tickets
		.Where(t => t.IsResolved == true
			&& t.AssociatedVersionOS.VersionKey.ProductKeyId == productId1
    		&& t.Description != null
    		&& t.DateCreat >= dateStart
    		&& t.DateCreat <= dateEnd)
    	.AsEnumerable() // Ramène les données dans la mémoire locale
    	.Where(t => allWords.All(word => t.Description.Contains(word)));
	GetAllTicketsOfThisProductIDWithTheseWordsSolvedInThisTimeLap.Dump();/**/
	
	//10
	var GetAllTicketsOfThisVersionIDWithTheseWordsSolvedInThisTimeLap = Tickets
		.Where(t => t.IsResolved == true
			&& t.AssociatedVersionOS.VersionKeyId == versionId3
    		&& t.Description != null
    		&& t.DateCreat >= dateStart
    		&& t.DateCreat <= dateEnd)
    	.AsEnumerable() // Ramène les données dans la mémoire locale
    	.Where(t => allWords.All(word => t.Description.Contains(word)));
	GetAllTicketsOfThisVersionIDWithTheseWordsSolvedInThisTimeLap.Dump();/**/
	
	
	
	
}