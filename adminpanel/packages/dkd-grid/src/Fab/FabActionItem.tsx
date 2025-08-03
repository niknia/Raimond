import type { ReactElement } from "react";
import { ActionIcon, Tooltip } from "@mantine/core";

interface FabActionItemProps {
  icon: ReactElement;
  onClick?: () => void;
  label?: string;
  className?: string;
  rtl?: boolean;
}

const FabActionItem = ({ 
  icon, 
  onClick, 
  label, 
  className,
  rtl = false
}: FabActionItemProps) => {
  return (
    <Tooltip 
      label={label} 
      position={rtl ? "right" : "left"}
      withArrow 
      disabled={!label}
      transitionProps={{ transition: "fade", duration: 200 }}
    >
      <ActionIcon
        onClick={onClick}
        variant="light"
        color="blue"
        size="lg"
        radius="xl"
        className={className}
        aria-label={label}
        style={{
          transition: 'all 0.2s ease',
          '&:hover': {
            transform: 'scale(1.1)',
          },
        }}
      >
        {icon}
      </ActionIcon>
    </Tooltip>
  );
};

export default FabActionItem;