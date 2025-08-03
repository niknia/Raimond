import {
  type UseControllerProps,
  useController,
  type FieldValues,
} from "react-hook-form";
import {
  Select as $Select,
  type ComboboxItem,
  type SelectProps as $SelectProps,
} from "@mantine/core";

// تعریف نوع SelectProps
export type SelectProps<T extends FieldValues> = UseControllerProps<T> & {
  onChange?: (value: string | null, option?: ComboboxItem) => void; // تغییر نوع onChange
} & Omit<$SelectProps, "value" | "defaultValue">;

export function Select<T extends FieldValues>({
  name,
  control,
  defaultValue,
  rules,
  shouldUnregister,
  onChange, // تابع onChange اختیاری
  ...props
}: SelectProps<T>) {
  const {
    field: { value, onChange: fieldOnChange, ...field },
    fieldState,
  } = useController<T>({
    name,
    control,
    defaultValue,
    rules,
    shouldUnregister,
  });

  return (
    <$Select
      value={value}
      onChange={(e, option) => {
        // فراخوانی fieldOnChange از react-hook-form
        fieldOnChange(e);

        // فراخوانی تابع onChange اختیاری اگر وجود داشته باشد
        if (onChange) {
          onChange(e, option);
        }
      }}
      error={fieldState.error?.message}
      {...field}
      {...props}
    />
  );
}