import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Users } from '../interfaces/user.interface';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  private URL = 'http://localhost:5022/api/user'

  constructor(private http: HttpClient) { }

  getUsers() {
    return this.http.get<Users[]>(this.URL);
  }

  getUserById(id: string) {
    return this.http.get<Users>(`${this.URL}/${id}`);
  }

  createUser(user: Users) {
    return this.http.post<Users>(this.URL, user);
  }

  updateUser(id: string, user: Users) {
    return this.http.put<Users>(`${this.URL}/${id}`, user);
  }

  deleteUser(id: string) {
    return this.http.delete<string>(`${this.URL}/${id}`);
  }

}
