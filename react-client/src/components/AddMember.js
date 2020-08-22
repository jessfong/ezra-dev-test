import React, { Component } from 'react'

export class AddMember extends Component {
  static displayName = AddMember.name

  constructor(props) {
    super(props)
  }

  async addMember() {
    // TODO
    throw 'Implement me'
  }

  render() {
    return (
      <div>
        <h1>Add Member</h1>

        {/* TODO */}
        {/* Implement me */}

        <button className="btn btn-primary" onClick={this.addMember}>
          Add
        </button>
      </div>
    )
  }
}
