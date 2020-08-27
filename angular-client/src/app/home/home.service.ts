import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Member } from './member';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HomeService {
  private url = 'http://localhost:5000/members/';
  editMember: Member;

  constructor(private http: HttpClient) { }

  getMembers(): Observable<Member[]> {
    return this.http.get<Member[]>(this.url);
  }

  deleteMember(id: string): Observable<any> {
    return this.http.delete(this.url + id);
  }

  updateMember(): Observable<any> {
    return this.http.put(this.url + this.editMember.id, this.editMember);
  }

  getMemberById(id: string): Observable<Member> {
    return this.http.get<Member>(this.url + id);
  }

  addMember(member: Member): Observable<any> {
    return this.http.post(this.url, member);
  }
}
