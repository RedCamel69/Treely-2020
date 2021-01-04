import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators, AbstractControl, ValidationErrors } from '@angular/forms';
import { Search } from 'src/models/search';
import { SearchResponse, WikipediaSearchResponse, webPages, queryContext, value } from 'src/models/search-response';
import { Suggestions } from 'src/models/autocomplete-response';
import { SearchService } from '../../services/search.service';
import { AutocompleteService } from '../../services/autocomplete.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  searchForm: FormGroup;


  noresults: boolean;

  search: Search;
  results: SearchResponse;
  results2: SearchResponse;

  wikiResults: WikipediaSearchResponse;
  wikiExtract: string;
  weHaveWikiExtract: boolean;
  displayWikiExtract: boolean;


  searchComplete: boolean;
  autocompleteResponse: Suggestions;

  count: number;
  offset: number;
  currentPage: number;

  values = '';
  hideSuggestions: boolean;
  hideResults: boolean;

  currentSuggestionSelection = -1;

  isShow = false;

  hideTitleDiv = false;

  constructor(private searchService: SearchService,
    private autocompleteService: AutocompleteService,
    private fb: FormBuilder,
    private route: ActivatedRoute) { }

  ngOnInit() {

    this.noresults = false;

    this.search = new Search();
    this.results = new SearchResponse();
    this.results.webPages = new webPages();
    this.results.webPages.value = new Array<value>();
    this.results.queryContext = new queryContext();

    this.hideSuggestions = true;
    this.hideResults = false;

    this.weHaveWikiExtract = false;

    this.searchForm = this.fb.group({
      search: [null, [Validators.required]]
    });

    this.route.params.subscribe(params => {
      //console.log(params);

      if (params['count']) {
        this.count = params['count'];
      }
      else {
        this.count = 5;
      }

      if (params['offset']) {
        this.offset = params['offset'];
      }
      else {
        this.offset = 0;
      }

      if (params['search']) {


        console.log(params['search'])
        console.log('count:' + params['count'])
        console.log(params['offset'])

        this.search.Phrase = params['search'];

        this.callSearchService(this.search.Phrase, this.count, this.offset);

        this.searchForm.get('search').patchValue(this.search.Phrase);



      }
    });


    this.currentPage = 0;
  }

  doSearch(count: number, offset: number) {

    this.hideResults = true;
    this.hideSuggestions = true;

    if (offset === 0) {
      this.currentPage = 0;
      this.displayWikiExtract = true;
    }
    else {
      this.currentPage = offset / count;
      this.displayWikiExtract = false;
    }


    this.search.Phrase = this.searchForm.get('search').value;

    // this.searchService.search(this.search.Phrase, 5, 0);

    this.callSearchService(this.search.Phrase, count, offset);


    this.count = count;
    this.offset = offset;

    this.hideSuggestions = true;


  }

  previousPage() {
    if (this.currentPage > 0) {
      this.currentPage = this.currentPage - 1;
    }
    this.doSearch(10, this.currentPage * 10);
  }


  nextPage() {
    this.currentPage = this.currentPage+1;
    this.doSearch(10, this.currentPage * 10);
  }


  callSearchService(phrase: string, count: number, offset: number) {

    this.searchComplete = false;
    this.hideSuggestions = true;

    var spinner = document.getElementById("spinner");
    spinner.className = "fa fa-spinner fa-5x fa-spin";

    if (offset == 0) {
      this.callWikiPedia(phrase, true);
    }
    
    this.searchService.apisearch(phrase, count, offset).subscribe(
      data => {

        if (data != null) {
          this.results = JSON.parse(data.toString()) as SearchResponse;
          console.log(data);
          console.log(this.results);
        }
        else {
          console.log('Error getting results');
          this.search = new Search();
          this.results = new SearchResponse();
          this.results.webPages = new webPages();
          this.results.webPages.value = new Array<value>();
          this.results.queryContext = new queryContext();

          this.noresults = true;
        }

      },
      err => console.error(err),
      () => {
        this.hideSuggestions = true;
        this.searchComplete = true;
      }
    );
  }


  callWikiPedia(phrase: string, displayResults: boolean) {


    this.weHaveWikiExtract = false;


    this.searchService.wikipediaSearch(phrase).subscribe(
      data => {
        console.log(data);

        this.wikiResults = data as WikipediaSearchResponse;

        console.log("this.wikiResults" + this.wikiResults);

        //  console.log(this.wikiResults.query.pages[Object.keys(this.wikiResults.query.pages)[0]].extract;

        if (this.wikiResults.query.pages[Object.keys(this.wikiResults.query.pages)[0]].extract !== undefined &&
          this.wikiResults.query.pages[Object.keys(this.wikiResults.query.pages)[0]].extract.indexOf("may refer to") == -1) {

          this.weHaveWikiExtract = true;
          this.wikiExtract = this.wikiResults.query.pages[Object.keys(this.wikiResults.query.pages)[0]].extract;
        }

        console.log("this.weHaveWikiExtract" + this.weHaveWikiExtract);

        // console.log(this.wikiResults.query.pages[0].extract);

        //if (data.query.pages[Object.keys(data.query.pages)[0]].extract !== undefined) {

        //    console.log(data.query.pages[Object.keys(data.query.pages)[0]].extract);
        //}

      },
      err => console.error(err),
      () => {
        //this.searchComplete = true;

        this.displayWikiExtract = displayResults && this.weHaveWikiExtract;
      }
    );
  }

  flipWiki() {
    this.hideResults = !this.hideResults;
    this.displayWikiExtract = !this.displayWikiExtract;
  }

  doSomething() {
    this.hideResults = false;
  }


  autocomplete(term) {

    this.autocompleteService.autocomplete(term).subscribe(
      data => {
        // this.autocompleteResponse = data as Suggestions;

       this.autocompleteResponse = JSON.parse(data.toString()) as Suggestions;

        this.hideSuggestions = false;


      }
    )
  }

  onKey(event: any) {
    if (event.code === "Enter") {
      this.hideSuggestions = true;
      this.doSearch(10, 0);
      console.log(this.hideSuggestions);
    }


    if (event.code !== "ArrowDown" && event.code !== "ArrowLeft" && event.code !== "ArrowRight" && event.code !== "ArrowUp") { 
      /*Display Suggestions */
      this.values = event.target.value;

      if (this.values.length > 2) {
        this.autocomplete(this.values);
        this.hideSuggestions = false;
      }
      else {
        this.hideSuggestions = true;
      }
    }

    /*End Display Suggestions */


    /* Defining Search? */
    var definingSearch = false;
    var selectedSearch = "";

    if (event.srcElement.id === "search") {
      definingSearch = true;
    }

    var index = -1;
    var numberOfSuggestions = document.getElementsByClassName("suggestion-list").length;


    ////arrow down
    if (definingSearch && event.code === "ArrowDown") {
      console.log('down');
      console.log(numberOfSuggestions)

      if (this.currentSuggestionSelection == -1 || this.currentSuggestionSelection == 8) {
        this.currentSuggestionSelection = 1
      }
      else {
        this.currentSuggestionSelection = this.currentSuggestionSelection + 1;
      }

      this.search.Phrase = this.autocompleteResponse.suggestionGroups[0].searchSuggestions[this.currentSuggestionSelection - 1].displayText;

      this.searchForm.patchValue({ search: this.search.Phrase });

    }

    ////arrow up
    if (definingSearch && event.code === "ArrowUp") {

      if (this.currentSuggestionSelection == 1) {
        this.currentSuggestionSelection = 8
      }
      else {
        this.currentSuggestionSelection = this.currentSuggestionSelection - 1;
      }

      this.search.Phrase = this.autocompleteResponse.suggestionGroups[0].searchSuggestions[this.currentSuggestionSelection - 1].displayText;

      this.searchForm.patchValue({ search: this.search.Phrase });

    }

  }

  useSuggestion(suggestion) {

    this.searchForm.patchValue({ search: suggestion.displayText });

    this.hideSuggestions = true;


  }

  toggleDisplay() {
    this.isShow = !this.isShow;
  }

  toggelWikiExtract() {
    this.displayWikiExtract = !this.displayWikiExtract;
  }

  scrollToTop() {
    this.hideTitleDiv = true;

    //bootstrap tablet breakpoint
    if (window.innerWidth < 768) {
      window.scrollBy(0, document.getElementById("titleDiv").offsetHeight);
    }
  }

  onFocus() {

  }


  onBlur() {

  }
}
