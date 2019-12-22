import React from 'react'
import Button from '@material-ui/core/Button'
import { TextField } from '@material-ui/core';
export default class Sample extends React.Component
{
    constructor()
    {
        super();
        this.state={
            data:[
            {
                "name":"Satya",
                "age":25
            },
            {
                "name":"Samir",
                "age":25
            },
            {
                "name":"Gajja",
                "age":26
            }

            ]
        }
       
    }
  
    render()
    {
        const exa=this.state.data.map((data1)=>
        {
            return (<div><h1>{data1.name}</h1>
            <h1>{data1.age}</h1>
            </div>)
        } )

        return(
<div>
  {exa}
</div>

        )
    }
}