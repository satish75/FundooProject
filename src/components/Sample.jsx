import React from 'react';
import { withStyles } from '@material-ui/core/styles';
import { green } from '@material-ui/core/colors';
import Radio from '@material-ui/core/Radio';



export default function Sample() {
  const [selectedValue, setSelectedValue] = React.useState('a');

  const handleChange = event => {
    setSelectedValue(event.target.value);
  };

  return (
    <div>
   <span id="service-type">Service Type : </span> 
      <Radio
        checked={selectedValue === 'a'}
        onChange={handleChange}
        value="a"
        color="default"
      
        name="radio-button-demo"
        inputProps={{ 'aria-label': 'A' }}
      />
   <label>advance</label>

      <Radio
        checked={selectedValue === 'b'}
        onChange={handleChange}
        value="b"
        color="default"
        name="radio-button-demo"
        inputProps={{ 'aria-label': 'B' }}
        size="small"
      />
      <label>basic</label>
    </div>
  );
}