import React, { useState } from "react";
import { ActionIcon, Transition, Box } from "@mantine/core";
import { IconPlus, IconX  } from "@tabler/icons-react";

export type Direction = "up" | "down" | "left" | "right";

export interface FabActionButtonProps {
  direction?: Direction;
  className?: string;
  position?: {
    top?: string | number;
    bottom?: string | number;
    left?: string | number;
    right?: string | number;
  };
  children?: React.ReactNode;
  primaryIcon?: React.ReactNode;
  closeIcon?: React.ReactNode;
  rtl?: boolean;
}

const FabActionButton = ({
  direction = "up",
  className,
  position = { bottom: "2rem", right: "2rem" },
  children,
  primaryIcon = <IconPlus />,
  closeIcon = <IconX />,
  rtl = false,
}: FabActionButtonProps) => {
  const [isOpen, setIsOpen] = useState(false);

  const toggleMenu = () => setIsOpen(!isOpen);

  const getMenuPosition = () => {
    switch (direction) {
      case "up":
        return { 
          bottom: "100%", 
          marginBottom: "0.5rem", 
          [rtl ? 'right' : 'left']: "0", 
          transform: rtl ? "translateX(0)" : "translateX(0)"
        };
      case "down":
        return { 
          top: "100%", 
          marginTop: "0.5rem", 
          [rtl ? 'right' : 'left']: "0", 
          transform: rtl ? "translateX(0)" : "translateX(0)"
        };
      case "left":
        return { 
          right: "100%", 
          marginRight: "0.5rem", 
          top: "50%", 
          transform: "translateY(-50%)" 
        };
      case "right":
        return { 
          left: "100%", 
          marginLeft: "0.5rem", 
          top: "50%", 
          transform: "translateY(-50%)" 
        };
      default:
        return { 
          bottom: "100%", 
          marginBottom: "0.5rem", 
          [rtl ? 'right' : 'left']: "0", 
          transform: rtl ? "translateX(0)" : "translateX(0)"
        };
    }
  };

  const getFlexDirection = () => {
    switch (direction) {
      case "up": return "column-reverse";
      case "down": return "column";
      case "left": return "row-reverse";
      case "right": return "row";
      default: return "column-reverse";
    }
  };

  const positionStyle: React.CSSProperties = {
    top: position.top !== undefined ? (typeof position.top === "number" ? `${position.top}px` : position.top) : undefined,
    bottom: position.bottom !== undefined ? (typeof position.bottom === "number" ? `${position.bottom}px` : position.bottom) : undefined,
    left: position.left !== undefined ? (typeof position.left === "number" ? `${position.left}px` : position.left) : undefined,
    right: position.right !== undefined ? (typeof position.right === "number" ? `${position.right}px` : position.right) : undefined,
  };

  return (
    <Box 
      className={className} 
      style={{ position: "absolute", zIndex: 50, ...positionStyle }}
    >
      <Box style={{ position: "relative" }}>
        <ActionIcon
          onClick={toggleMenu}
          variant="filled"
          color="purple"
          size="md"
          radius="xl"
          className={`transition-all duration-200 ${isOpen ? "rotate-45" : ""}`}
          style={{ width: '2.5rem', height: '2.5rem' }}
          aria-label="Toggle menu"
        >
          {isOpen ? closeIcon : primaryIcon}
        </ActionIcon>
        
        <Transition mounted={isOpen} transition="fade" duration={400}>
          {(styles) => (
            <Box 
              component="ul"
              style={{
                ...styles,
                position: "absolute",
                display: "flex",
                gap: "0.5rem",
                flexDirection: getFlexDirection(),
                ...getMenuPosition(),
                listStyle: "none",
                margin: 0,
                padding: 0,
                paddingBottom: "0.3rem",
                alignItems: rtl ? 'flex-end' : 'flex-start',
              }}
            >
              {React.Children.map(children, (child, index) => (
                <Box 
                  component="li"
                  style={{ 
                    animationDelay: `${index * 50}ms`,
                    opacity: 100,
                    animation: 'fadeIn 0.2s ease-out forwards',
                  }}
                >
                  {child}
                </Box>
              ))}
            </Box>
          )}
        </Transition>
      </Box>
    </Box>
  );
};

export default FabActionButton;
