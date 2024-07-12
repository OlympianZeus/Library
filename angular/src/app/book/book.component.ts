import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { BookService, BookDto, bookTypeOptions, AuthorLookupDto } from '@proxy/books';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';


@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss'],
  providers: [
    ListService,
    { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter}
  ],
  
})
export class BookComponent implements OnInit {
  book = { items: [], totalCount: 0 } as PagedResultDto<BookDto>;

  selectdBook = {} as BookDto;//this selects the book for update

  authors$: Observable<AuthorLookupDto[]>

  form: FormGroup;
  bookTypes = bookTypeOptions;

  isModalOpen = false;

  constructor(
    public readonly list: ListService,
    private bookService: BookService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService
  ) {
    this.authors$ = bookService.getAuthorLookup().pipe(map((r) => r.items));
  }

  ngOnInit() {
    const bookStreamCreator = (query) => this.bookService.getList(query);

    this.list.hookToQuery(bookStreamCreator).subscribe((response) => {
      this.book = response;
    });
  }

  createBook(){//Creates the book
    this.selectdBook = {} as BookDto; //this code resets the selected book
    this.buildForm();
    this.isModalOpen = true;
  }

  //Add editBook method
  editBook(id:string){
    this.bookService.get(id).subscribe((book)=>{
      this.selectdBook = book;
      this.buildForm();
      this.isModalOpen = true;
    })
  }

  //BuildForm method
  buildForm(){
    this.form = this.fb.group({
      name: [this.selectdBook.name || '', Validators.required],
      type: [this.selectdBook.type || null, Validators.required],
      publishDate: [
        this.selectdBook.publishDate? new Date(this.selectdBook.publishDate): null,
        Validators.required,
      ],
      price: [this.selectdBook.price || null, Validators.required],
    });
  }

  //Save method
  save(){
    if(this.form.invalid)
    {
      return;
    }

    const request = this.selectdBook.id
    ?this.bookService.update(this.selectdBook.id, this.form.value)
    :this.bookService.create(this.form.value);

    request.subscribe(()=>{
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', 'AbpAccount::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.bookService.delete(id).subscribe(() => this.list.get());
      }
    });
  }
}
