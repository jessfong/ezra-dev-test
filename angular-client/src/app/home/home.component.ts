import { Component, Inject } from '@angular/core'
import { HttpClient } from '@angular/common/http'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  public members: Member[]

  constructor(http: HttpClient) {
    http.get<Member[]>('http://localhost:5000/members').subscribe(
      (result) => {
        this.members = result
      },
      (error) => console.error(error),
    )
  }

  deleteMember(id) {
    // TODO
    throw 'Implement me'
  }

  editMember(id) {
    // TODO
    throw 'Implement me'
  }
}

interface Member {
  Id: string
  Name: number
  Email: number
}
