import { Spotlight } from '@mantine/spotlight';
import { type FC, useState } from 'react';
import type { SpotlightWrapperProps } from './SpotlightWrapper.types';

export const SpotlightWrapper: FC<SpotlightWrapperProps> = ({ actions, setActions, children }) => {
    const [query, setQuery] = useState('');
  
    const filteredActions = (actions || []).filter((action) =>
      action.label?.toLowerCase().includes(query.toLowerCase())
    );
  
    // Example: Add a new action when a condition is met
    const addExampleAction = () => {
      setActions([
        ...(actions || []),
        {
          id: 'new-action',
          label: 'New Action',
          description: 'Added dynamically',
          onClick: () => console.log('New action clicked'),
        },
      ]);
    };
  
    return (
      <Spotlight.Root query={query} onQueryChange={setQuery}>
        <Spotlight.Search placeholder="Search..." />
        <Spotlight.ActionsList>
          {filteredActions.map((action) => (
            <Spotlight.Action
              key={action.id}
              label={action.label}
              description={action.description}
              onClick={action.onClick}
            />
          ))}
        </Spotlight.ActionsList>
        {/* Example button to trigger setActions */}
        <button type="button" onClick={addExampleAction}>Add Action</button>
        {children}
      </Spotlight.Root>
    );
  };