import { useLocalStorage } from "@mantine/hooks";
import type { ThemeName } from "../util/theme";
import { themes } from "../Colors";


export function useThemes() {
	const [theme, setTheme] = useLocalStorage<ThemeName>({
		key: "theme",
		defaultValue: "corporate",
		serialize: (value) => value,
		deserialize: (value) => {
			if (value !== undefined && Object.keys(themes).includes(value)) {
				return value as ThemeName;
			}
			return "corporate";
		},
	});

	return { themes, currentThemeName: theme, setCurrentThemeName: setTheme };
}
