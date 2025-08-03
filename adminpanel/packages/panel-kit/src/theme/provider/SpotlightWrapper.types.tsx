import type { SpotlightActionData } from '@mantine/spotlight';

export interface SpotlightWrapperProps {
    actions: SpotlightActionData[]; // Type for actions
    setActions: (actions: SpotlightActionData[]) => void; // Type for setActions
    children?: React.ReactNode; // Optional children prop
  }