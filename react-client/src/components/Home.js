import React, { Component } from 'react'

import './Home.css'

export class Home extends Component {
  static displayName = Home.name

  constructor(props) {
    super(props)
    this.state = { members: [], loading: true }
  }

  componentDidMount() {
    this.populateMembers()
  }

  renderMembersTable(members) {
    return (
      <table className="table table-striped">
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Email</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {members.map((member) => (
            <tr key={member.id}>
              <td>{member.id}</td>
              <td>{member.name}</td>
              <td>{member.email}</td>
              <td className="btn-group">
                <button
                  className="img-btn btn-link"
                  onClick={() => this.deleteMember(member.id)}
                >
                  <img src="/delete.svg" width="12px" height="12px" />
                </button>
                <button
                  className="img-btn btn-link"
                  onClick={() => this.editMember(member.id)}
                >
                  <img src="/edit.svg" width="12px" height="12px" />
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    )
  }

  render() {
    let contents = this.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      this.renderMembersTable(this.state.members)
    )

    return (
      <div>
        <h1 id="tabelLabel">Ezra Members</h1>

        {contents}
      </div>
    )
  }

  async populateMembers() {
    const response = await fetch('http://localhost:5000/members')
    const data = await response.json()
    this.setState({ members: data, loading: false })
  }

  async deleteMember(memberId) {
    // TODO
    throw 'Implement me'
  }

  async editMember(memberId) {
    // TODO
    throw 'Implement me'
  }
}
