import { NgModule } from '@angular/core';
import { AuthorRoutingModule } from './author-routing.module';
import { AuthorComponent } from './author.component';
import { SharedModule } from '../shared/shared.module';
import { NgbDatepickerModule} from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [
    AuthorComponent
  ],
  imports: [
    AuthorRoutingModule,
    SharedModule,
    NgbDatepickerModule
  ]
})
export class AuthorModule { }
