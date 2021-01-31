
Feature: SearchUsedCars
	In order to view used cars details with number plate, kilometres, body and seats
	As a user
	I want to be able to search any existing used car listing

@smokeHomePageSearch
Scenario: User can search used car from homepage
	Given user has navigated to the Homepage
	When user enter a <SearchKeyword> for cars category
	And user presses Search Magnifier
	Then the page displays used car listing based on keyword
	When user selects a used car listing
	Then the page displays selected used cars listing details
	Examples: 
	| SearchKeyword |
	| BMW           |

@smokeHomePageSearch
Scenario: User search criteria has no match from homepage
	Given user has navigated to the Homepage
	When user enter a <SearchKeyword> for cars category
	And user presses Search Magnifier
	Then the page displays no results based on keyword
	Examples: 
	| SearchKeyword |
	| BMW Toyota    |

@smokeMotorsPageSearch
Scenario: User can view used car listing from default results
	Given user has navigated to Trademe Motors page
	When user selects a used car listing
	Then the page displays selected used cars listing details

@smokeMotorsPageSearch
Scenario: Search criteria found matches in used car listing
	Given user has navigated to Trademe Motors page
	And user enter used cars search details <WheelDrive>,<Transmission>,<Keyword>,<MinPrice>,<MaxPrice>,<MinOdometer>,<MaxOdometer>,<MinYear>,<MaxYear>,<Region>
	When user presses Search
	Then the page displays used car listing
	When user selects a used car listing
	Then the page displays selected used cars listing details
	Examples: 
	 | WheelDrive | Transmission     | Keyword | MinPrice | MaxPrice | MinOdometer | MaxOdometer | MinYear | MaxYear | Region     |
	 | 2WD or 4WD | Any transmission | BMW     | Any      | $80k     | Any         | 200k        | Any     | 2021    | NZ         |
	 | 2WD or 4WD | Automatic=2\|3   |         | Any      | Any      | 500         | Any         | 1998    | Any     | Canterbury |
	    
@smokeMotorsPageSearch
Scenario: Search criteria found no match in used car listing
	Given user has navigated to Trademe Motors page
	And user enter used cars search details <WheelDrive>,<Transmission>,<Keyword>,<MinPrice>,<MaxPrice>,<MinOdometer>,<MaxOdometer>,<MinYear>,<MaxYear>,<Region>
	When user presses Search
	Then the page displays no search results
	Examples: 
	 | WheelDrive | Transmission     | Keyword          | MinPrice | MaxPrice | MinOdometer | MaxOdometer | MinYear | MaxYear | Region     |
	 | 2WD or 4WD | Any transmission | No car match     | Any      | $80k     | Any         | 200k        | Any     | 2021    | NZ         |